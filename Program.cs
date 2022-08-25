using Task_25_7_1.BLL.Services;
using Task_25_7_1.PLL.Views;
using Task_25_7_1.PLL.Views.Book;
using Task_25_7_1.PLL.Views.User;
using Task_25_7_1.PLL.Views.UserBook;

namespace Task_25_7_1
{
    internal class Program
    {
        public static MainView mainView = null!;
        public static ChangeDataView changeDataView = null!;
        public static DataView dataView = null!;

        public static UserInfoView userInfoView = null!;
        public static AddUserView addUserView = null!;
        public static DelUserView delUserView = null!;
        public static UserNameUpdateView userNameUpdateView = null!;
        public static AddBookView addBookView = null!;
        public static DelBookView delBookView = null!;
        public static BookInfoView bookInfoView = null!;
        public static BookYearUpdateView bookYearUpdateView = null!;
        public static UserBookInfoView userBookInfoView = null!;
        public static IssueBookToUserView issueBookToUserView = null!;
        public static BookReturnView bookReturnView = null!;

        public static GetListBooksOfGenreAndYearsView getListBooksOfGenreAndYearsView = null!;
        public static GetCountBooksByAuthorView getCountBooksByAuthorView = null!;
        public static GetCountBooksByGenreView getCountBooksByGenreView = null!;
        public static CheckBookOfAuthorAndTitleView checkBookOfAuthorAndTitleView = null!;
        public static CheckBookOfAuthorAndTitleInUserView checkBookOfAuthorAndTitleInUserView = null!;
        public static GetCountBooksInUserView getCountBooksInUserView = null!;
        public static GetLatestPublishedBookView getLatestPublishedBookView = null!;
        public static GetAllBooksSortedByTitleView getAllBooksSortedByTitleView = null!;
        public static GetAllBooksSortedByYearOfIssueView getAllBooksSortedByYearOfIssueView = null!;

        static void Main()
        {
            CommonServices сommonServices = new CommonServices();
            UserServices userServices = new UserServices();
            BookServices bookServices = new BookServices();
            UserBookServices userBookServices = new UserBookServices();

            mainView = new MainView();
            changeDataView = new ChangeDataView();
            dataView = new DataView();

            userInfoView = new UserInfoView(userServices);
            addUserView = new AddUserView(userServices);
            delUserView = new DelUserView(userServices);
            userNameUpdateView = new UserNameUpdateView(userServices);
            addBookView = new AddBookView(bookServices);
            delBookView = new DelBookView(bookServices);
            bookInfoView = new BookInfoView(bookServices);
            bookYearUpdateView = new BookYearUpdateView(bookServices);
            userBookInfoView = new UserBookInfoView(userBookServices);
            issueBookToUserView = new IssueBookToUserView(userBookServices);
            bookReturnView = new BookReturnView(userBookServices);

            getListBooksOfGenreAndYearsView = new GetListBooksOfGenreAndYearsView(bookServices);
            getCountBooksByAuthorView = new GetCountBooksByAuthorView(bookServices);
            getCountBooksByGenreView = new GetCountBooksByGenreView(bookServices);
            checkBookOfAuthorAndTitleView = new CheckBookOfAuthorAndTitleView(bookServices);
            checkBookOfAuthorAndTitleInUserView = new CheckBookOfAuthorAndTitleInUserView(userBookServices);
            getCountBooksInUserView = new GetCountBooksInUserView(userServices);
            getLatestPublishedBookView = new GetLatestPublishedBookView(bookServices);
            getAllBooksSortedByTitleView = new GetAllBooksSortedByTitleView(bookServices);
            getAllBooksSortedByYearOfIssueView = new GetAllBooksSortedByYearOfIssueView(bookServices);

            Console.WriteLine("При первом запуске необходимо выполнить инициализацию БД!");
            Console.WriteLine("Для этого введите: Да");
            if(Console.ReadLine() == "Да")
            {
                сommonServices.InitializationBD();
            }

            userInfoView.Show();
            bookInfoView.Show();

            mainView.Show();
        }
    }
}