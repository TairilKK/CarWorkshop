﻿using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarWorkshop.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string type, string message)
        {
            var notification = new Notification(type, message);
            controller.TempData["notification"] = JsonSerializer.Serialize(notification);
        }
    }
}
