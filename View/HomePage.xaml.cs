﻿using WeatherFlex.View;
using WeatherFlex.Model;
using WeatherFlex.ViewModels;
using WeatherFlex.View.Feedback;
using WeatherFlex.Database;

namespace WeatherFlex;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        Content = new InfoView("Loading data...");

        WeatherViewModel weatherViewModel = new();
        await weatherViewModel.GetUserWeatherAsync();

        SettingsDao settingsDao = new();
        Settings userSettings = await settingsDao.Get();
        await settingsDao.CloseAsync();

        Content = new WeatherView(weatherViewModel, Window, userSettings);
    }
}
