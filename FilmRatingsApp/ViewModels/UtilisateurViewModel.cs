using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmsRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.ViewModels;

public partial class UtilisateurViewModel : ObservableObject
{
    private string searchMail;
    private Utilisateur utilisateurSearch;

    public string SearchMail
    {
        get
        {
            return searchMail;
        }
        set
        {
            searchMail = value;
            OnPropertyChanged("SearchMail");
        }
    }
    public Utilisateur UtilisateurSearch 
    {
        get
        {
            return utilisateurSearch;
        }
        set
        {
            utilisateurSearch = value;
            OnPropertyChanged();
        }
    }
    public IRelayCommand BtnSearchUtilisateurCommand { get; }
    public IRelayCommand BtnModifyUtilisateurCommand { get; }
    public IRelayCommand BtnClearUtilisateurCommand { get; }
    public IRelayCommand BtnAddUtilisateurCommand { get; }

    public UtilisateurViewModel()
    {
        SearchMail = "";
        UtilisateurSearch = new Utilisateur();

        BtnSearchUtilisateurCommand = new RelayCommand(ActionSearchUtilisateurAsync);
        BtnModifyUtilisateurCommand = new RelayCommand(ActionModifyUtilisateurAsync);
        BtnClearUtilisateurCommand = new RelayCommand(ActionClearUtilisateurAsync);
        BtnAddUtilisateurCommand = new RelayCommand(ActionAddUtilisateurAsync);
    }

    public async void ActionSearchUtilisateurAsync()
    {
        if (!String.IsNullOrWhiteSpace(SearchMail))
        {
            WSService service = new WSService("https://localhost:7147/api/");

            Utilisateur? result = await service.GetUtilisateurAsync("utilisateurs", SearchMail);
            if (result == null)
            {
                MessageAsync("Utilisateur non trouvé !", "Erreur");
            }
            else
            {
                UtilisateurSearch = result;
            }
        }
    }
    public async void ActionModifyUtilisateurAsync()
    {
    }
    public async void ActionClearUtilisateurAsync()
    {
    }
    public async void ActionAddUtilisateurAsync()
    {
    }

    private async void MessageAsync(string texte, string titre)
    {
        ContentDialog contentDialog = new ContentDialog
        {
            Title = titre,
            Content = texte,
            CloseButtonText = "Ok"
        };

        contentDialog.XamlRoot = App.MainRoot.XamlRoot;
        await contentDialog.ShowAsync();
    }
}
