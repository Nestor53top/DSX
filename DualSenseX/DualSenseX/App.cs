using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace DualSenseX;

public partial class App : Application
{
	private void Application_Startup(object sender, StartupEventArgs e)
	{
		AppCenter.SetCountryCode(RegionInfo.CurrentRegion.TwoLetterISORegionName);
		AppCenter.Start("6cecec35-5776-4ebc-a6da-580da439923d", typeof(Analytics), typeof(Crashes));
	}

	private void Application_Exit(object sender, ExitEventArgs e)
	{
		if (((IEnumerable)Application.Current.Windows).Cast<Window>().FirstOrDefault((Window window) => window is Main) is Main { App_TaskBarIcon: not null } main)
		{
			((UIElement)main.App_TaskBarIcon).Visibility = (Visibility)1;
		}
	}
}
