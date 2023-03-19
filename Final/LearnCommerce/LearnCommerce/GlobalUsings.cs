/*
 * Copyright (c) Learn MS NET, All Rights Reserved.
 * Author: Sam MacDonald - omacdon@learnmsnet.com
 * Created: 2/27/2023
 * Modified: 3/11/2023
 */

global using CommunityToolkit.Maui;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;

global using IdentityModel;
global using IdentityModel.Client;

global using LearnCommerce.Config;
global using LearnCommerce.Exceptions;
global using LearnCommerce.Extensions;
global using LearnCommerce.Handlers;
global using LearnCommerce.Helpers;
global using LearnCommerce.Infrastructure;
global using LearnCommerce.Models.Locations;
global using LearnCommerce.Models.Onboarding;
global using LearnCommerce.Models.Token;
global using LearnCommerce.Pages;
global using LearnCommerce.Resources.Strings;
global using LearnCommerce.Services.AppEnvironment;
global using LearnCommerce.Services.Dialog;
global using LearnCommerce.Services.Identity;
global using LearnCommerce.Services.Locations;
global using LearnCommerce.Services.Navigation;
global using LearnCommerce.Services.OpenUrl;
global using LearnCommerce.Services.Request;
global using LearnCommerce.Services.Settings;
global using LearnCommerce.Services.Theme;
global using LearnCommerce.Validations;
global using LearnCommerce.Validations.Interfaces;
global using LearnCommerce.ViewModels;
global using LearnCommerce.ViewModels.Base;

global using Microsoft.Extensions.Logging;
// global using Microsoft.Maui.Platform;

global using System.Collections.ObjectModel;
global using System.Diagnostics;
global using System.Net;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Security.Cryptography;
global using System.Text;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Windows.Input;