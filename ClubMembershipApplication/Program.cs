using ClubMembershipApplication;
using ClubMembershipApplication.Views;

IView mainView = Factory.GetMainViewObject();
mainView.RunView();

Console.ReadKey();