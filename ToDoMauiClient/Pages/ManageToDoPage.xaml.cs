using __XamlGeneratedCode__;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using ToDoMauiClient.DataServices;
using ToDoMauiClient.Models;

namespace ToDoMauiClient.Pages;

[QueryProperty(nameof(ToDo), "ToDo")]
public partial class ManageToDoPage : ContentPage
{
    private IRestDataService _dataService;
	ToDo _toDo;
	bool _isNew;

	public ToDo ToDo
	{
		get => _toDo;
		set 
		{
			_isNew = IsNew(value);
			_toDo = value;
			OnPropertyChanged();
		}
	}
    public ManageToDoPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
		BindingContext = this;

	}

	bool IsNew(ToDo toDo)
	{
			if( toDo.Id == 0)
				return true;
			return false;
	}

	async void OnSaveButtonClicked(ObjectSecurity sender, EventArgs e)
	{
		if (_isNew) 
		{
			Debug.WriteLine("---> Add new Item");
			await _dataService.AddToDoAsync(ToDo);
		}
		else 
		{
            Debug.WriteLine("---> Add new Item");
            await _dataService.UpdateToDoAsync(ToDo);
        }

		await Shell.Current.GoToAsync("..");
	}

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		await _dataService.DeleteToDoAsync(ToDo.Id);
		await Shell.Current.GoToAsync("..");
	}


    async void OnCancelButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}
}