using Noa.PocketUi.Main.ViewModels;
using Plugin.NFC;

namespace Noa.PocketUi.Main.Views;

public partial class Profile : ContentPage
{
    private readonly ProfileViewModel _profileViewModel;

    public Profile(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
        _profileViewModel = profileViewModel;
        BindingContext = profileViewModel;
    }

    Task ShowAlert(string message, string title = null) => DisplayAlert(string.IsNullOrWhiteSpace(title) ? "NFC" : title, message, "OK");


    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _profileViewModel.LoadUserData();

        CrossNFC.Legacy = true;

        if (CrossNFC.IsSupported)
        {
            if (!CrossNFC.Current.IsAvailable)
                Console.WriteLine("NFC is not available");

            if (!CrossNFC.Current.IsEnabled)
                Console.WriteLine("NFC is disabled");

            await AutoStartAsync().ConfigureAwait(false);
        }
    }

    async Task AutoStartAsync()
    {
        // Some delay to prevent Java.Lang.IllegalStateException "Foreground dispatch can only be enabled when your activity is resumed" on Android
        await Task.Delay(500);
        StartListeningIfNotiOS();
    }

    async Task StartListeningIfNotiOS()
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            SubscribeEvents();
            return;
        }
        await BeginListening();
    }

    void SubscribeEvents()
    {
        CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
        CrossNFC.Current.OnMessagePublished += Current_OnMessagePublished;
        CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
    }

    void UnsubscribeEvents()
    {
        CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;
        CrossNFC.Current.OnMessagePublished -= Current_OnMessagePublished;
        CrossNFC.Current.OnTagDiscovered -= Current_OnTagDiscovered;
    }

    async Task BeginListening()
    {
        try
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SubscribeEvents();
                CrossNFC.Current.StartListening();
            });
        }
        catch (Exception ex)
        {
            await ShowAlert(ex.Message);
        }
    }

    async void Current_OnMessageReceived(ITagInfo tagInfo)
    {
        Current_OnTagDiscovered(tagInfo, false);
    }


    async void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
    {
        if (!CrossNFC.Current.IsWritingTagSupported)
        {
            await ShowAlert("Writing tag is not supported on this device");
            return;
        }

        try
        {
            NFCNdefRecord record = new NFCNdefRecord
            {
                TypeFormat = NFCNdefTypeFormat.Mime,
                MimeType = "text/plain",
                Payload = NFCUtils.EncodeToByteArray(_profileViewModel.UserId)
            };

            if (!format && record == null)
                throw new Exception("Record can't be null.");

            tagInfo.Records = new[] { record };

            if (format)
                CrossNFC.Current.ClearMessage(tagInfo);
            else
            {
                CrossNFC.Current.PublishMessage(tagInfo, false);
                CrossNFC.Current.StartPublishing();
            }
        }
        catch (Exception ex)
        {
            await ShowAlert(ex.Message);
        }
    }

    async void Current_OnMessagePublished(ITagInfo tagInfo)
    {
        try
        {
            CrossNFC.Current.StopPublishing();
            if (tagInfo.IsEmpty)
                await ShowAlert("Formatting tag operation successful");
            else
                await ShowAlert("Writing tag operation successful");
        }
        catch (Exception ex)
        {
            await ShowAlert(ex.Message);
        }
    }
}