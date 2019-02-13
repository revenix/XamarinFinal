using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using System.Threading.Tasks;
using System.Diagnostics;
using Prism.Commands;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp;

public class ViewModelAbstraction : BindableBase, INavigationAware, IDestructible, IPageLifecycleAware
{

    #region Vars
    private readonly static string TAG = nameof(ViewModelAbstraction);
    protected INavigationService NavigationService { get; private set; }
    protected IUserDialogs UserDialogsService { get; private set; }
    protected IConnectivity Connectivity { get; set; }
    #endregion

    #region Vars Commands
    public DelegateCommand ReturnToPreviousPageCommand { get; private set; }
    public DelegateCommand ShowMenuCommand { get; set; }
    #endregion

    #region Properties
    private string titleToolbar;
    public string TitleToolbar
    {
        get => titleToolbar;
        set => SetProperty(ref titleToolbar, value);
    }
    private bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }
    #endregion

    #region Constructor
    public ViewModelAbstraction(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity)
    {
        NavigationService = navigationService;
        UserDialogsService = userDialogsService;
        Connectivity = connectivity;
        ReturnToPreviousPageCommand = new DelegateCommand(OnReturnToPreviousPageCommandExecuted);
        ShowMenuCommand = new DelegateCommand(ShowMenuCommandExecuted);
    }
    #endregion

    #region Methods Commands
    public virtual async void OnReturnToPreviousPageCommandExecuted()
    {
        await NavigationService.GoBackAsync();
    }

    public virtual void ShowMenuCommandExecuted()
    {
        App.Master.IsPresented = true;
    }
    #endregion

    #region Methods
    protected async Task<ResponseBase<T>> RunSafeApi<T>(Task<T> runMethod)
    {
        var result = new ResponseBase<T>
        {
            Status = TypeReponse.Error,
            Response = default(T)
        };
        try
        {
            if (Connectivity.IsConnected)
            {
                try
                {
                    result.Response = await runMethod;
                    if (!result.Response.Equals(null))
                    {
                        result.Status = TypeReponse.Ok;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, TAG);
                }
            }
            else
            {
                result.Status = TypeReponse.ConnectivityError;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message, TAG);
        }
        return result;
    }
    #endregion

    #region Life Cycle Page
    public virtual void Destroy(){ }

    public virtual void OnAppearing(){ }

    public virtual void OnDisappearing(){ }
    #endregion

    #region Navigation Methods
    public virtual void OnNavigatedFrom(INavigationParameters parameters){ }

    public virtual void OnNavigatedTo(INavigationParameters parameters){ }

    public virtual void OnNavigatingTo(INavigationParameters parameters){ }
    #endregion

}

