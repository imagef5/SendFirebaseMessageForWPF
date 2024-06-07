using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebaseAdmin.Messaging;
using System.Windows;

namespace SendPentaNotification.ViewModel;

public partial class MainViewModel : ObservableObject
{
    #region Private Area
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendMessageCommand))]
    private string? title;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendMessageCommand))]
    private string? message;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendMessageCommand))]
    private string? deviceID;
    #endregion

    [RelayCommand(CanExecute = nameof(canSendMessage))]
    private async Task SendMessage()
    {
        try
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = Title,
                    Body = Message,
                },
                Apns = new ApnsConfig
                {
                    Aps = new Aps
                    {
                        Sound = "default",
                    }
                },
                Token = DeviceID!.Trim()
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show("메지시가 발송되었습니다.", "성공", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("메시지 발송이 실패하였습니다." , "실패", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "오류", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool canSendMessage()
    {
        return !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Message) && !string.IsNullOrWhiteSpace(DeviceID);
    }
}
