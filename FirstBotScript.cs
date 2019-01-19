using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using System.Text;
using System.Data.SQLite;

namespace Firstbot1
{


    class MainClass
    {
        
        public const string Token = "792664059:AAHr6LcqwtTKebdzKxZ2porN_9_brqJYzns";

        public static void Main()
        {
            while(true){
                try{
                    GetMessages().Wait();
                }catch(Exception ex){
                    Console.WriteLine("Error: " + ex);
                }
            }
        }
        public static async Task GetMessages(){
            TelegramBotClient bot = new TelegramBotClient(Token);
            int offset = 0;
            int timeout = 0;
            int num = 0;

            try{

                await bot.SetWebhookAsync("");

                while(true){
                    var updates = await bot.GetUpdatesAsync(offset, timeout);

                    foreach(var update in updates){
                        var message = update.Message;

                        Console.WriteLine("message was catched: " + message.Text);

                        if (message.Text == "/start"){
                            var keyboard = new ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                    new  []{
                                    new KeyboardButton("1"),
                                    new KeyboardButton("2")
                                    }, new[] {
                                        new KeyboardButton("Hi")
                                    }
                                }
                            };

                            await bot.SendTextMessageAsync(message.Chat.Id, "Привет, я бот, который поможет тебе весело провести время ");
                        }

                        if (message.Text == "/task"){
                            await bot.SendTextMessageAsync(message.Chat.Id, "task... " + num);
                            num++;
                        }

                        if (message.Text == "/card1")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Card 1 ");
                        }

                        if (message.Text == "/card2")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Card 2 ");
                        }

                        if (message.Text == "/card3")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "Card 3 ");
                        }



                        offset = update.Id + 1;
                    }
                }
            }catch(Exception ex){
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
