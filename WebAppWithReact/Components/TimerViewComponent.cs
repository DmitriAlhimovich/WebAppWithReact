using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAppWithReact.Components
{
    [ViewComponent]
    public class MyTimer
    {   public string Invoke()
        {
            return $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}";
        }
    }
}
