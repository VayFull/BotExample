using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BotExample
{
    class Program
    {
        private static ITelegramBotClient _botClient;

        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("Ваш токен")
                {Timeout = TimeSpan.FromSeconds(10)};

            _botClient.OnMessage += Bot_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null)
                return;
            await _botClient.SendTextMessageAsync(
                e.Message.Chat,
                $"Your message:'{text}', /help для получения списка доступных команд").ConfigureAwait(false);
        }
    }
}
