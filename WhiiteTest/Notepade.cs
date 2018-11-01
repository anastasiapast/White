using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace WhiiteTest
{
    [TestClass]
    public class NotepadeTest
    {
        [TestMethod]
        public void SavingFileTest()
        {
            //Старт блокнота
            var notepad = Application.Launch("notepad");

            //Находим главное окно
            var winMain = notepad.GetWindow("Untitled - Notepad");

            //Находим в окне область ввода текста и пешем в нее "Hello, world!"
            var textArea = winMain.Get<TextBox>(SearchCriteria.ByAutomationId("15"));
            textArea.Text = "Hello, World!";

            //(eще вводить текст можно так: textArea.Enter("Hello, world!"))

            //На главном меню находим MenuBar
            var menu = winMain.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));

            //Навигация по меню осуществляется методом MenuItem который принимает список подменю
            var btnSaveAs = menu.MenuItem("File", "Save As...");

            //Кликаем по кнопке "Save As..."
            btnSaveAs.Click();

            //Получаем модальное диалоговое окно "Save As"
            var winSaveFileDialog = winMain.ModalWindow("Save As");

            //В диалоговом окне находим поле для ввода имени файла и пешем туда "C:\\test.txt"
            var tbFileName = winSaveFileDialog.MdiChild(SearchCriteria.ByAutomationId("1001"));
            tbFileName.Enter("C:\\Users\\apastukhova\\Documents\\test.txt");

            //Save
            var saveBtn = winSaveFileDialog.Get<Button>(SearchCriteria.ByText("Save"));
            saveBtn.Click();

            // Если файл уже существует, то может появиться окно подтверждения перезаписи файла
            //если такое окно нашлось, то кликаем кнопку "Yes"
            var winConfirmationDialog = winSaveFileDialog.ModalWindow("Confirm Save As");
            if (winConfirmationDialog != null)
            {
                winConfirmationDialog.Get<Button>(SearchCriteria.ByText("Yes")).Click();
            }

            //Закрываем приложение
            notepad.Close();

            //Проверяем наличие файла и его содержимое
            Assert.IsTrue(File.Exists("C:\\Users\\apastukhova\\Documents\\test.txt"));
            Assert.AreEqual(File.ReadAllText("C:\\Users\\apastukhova\\Documents\\test.txt"), "Hello, World!");
        }
    }
}
