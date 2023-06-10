using UnityEngine;

namespace IndustriesMeetsSunsetHarbor.Utils
{
    class AtlasUtils
    {
        public static string[] SpriteNames = new string[]
        {
            "Bread",
            "DrinkSupplies",
            "FoodSupplies",
            "Meals",
            "CannedFish",
            "OrderedMeals"
        };

        public static string[] NotificationSpriteNames = new string[]
        {
            "BuildingNotificationWaitingDeliveryCritical",
            "BuildingNotificationWaitingDelivery",
            "BuildingNotificationWaitingDeliveryFirst"
        };

        public static string[] RestaurantInfoIconButton = new string[]
        {
            "InfoIconRestaurantBase",
	    "InfoIconRestaurantDisabled",
	    "InfoIconRestaurantFocused",
	    "InfoIconRestaurantHovered",
	    "InfoIconRestaurantPressed",
        };

        public static void CreateAtlas()
        {
            if (TextureUtils.GetAtlas("RestaurantAtlas") == null)
            {
                TextureUtils.InitialiseAtlas("RestaurantAtlas");
                for (int i = 0; i < SpriteNames.Length; i++)
                {
                    TextureUtils.AddSpriteToAtlas(new Rect(32 * i, 0, 32, 32), SpriteNames[i], "RestaurantAtlas");
                }
            }
            if (TextureUtils.GetAtlas("DeliveryNotificationAtlas") == null)
            {
                TextureUtils.InitialiseAtlas("DeliveryNotificationAtlas");
                for (int i = 0; i < NotificationSpriteNames.Length; i++)
                {
                    TextureUtils.AddSpriteToAtlas(new Rect(82 * i, 0, 82, 82), NotificationSpriteNames[i], "DeliveryNotificationAtlas");
                }
            }
            if (TextureUtils.GetAtlas("RestaurantInfoIconButtonAtlas") == null)
            {
                TextureUtils.InitialiseAtlas("RestaurantInfoIconButtonAtlas");
                for (int i = 0; i < RestaurantInfoIconButton.Length; i++)
                {
                    TextureUtils.AddSpriteToAtlas(new Rect(36 * i, 0, 36, 36), RestaurantInfoIconButton[i], "RestaurantInfoIconButtonAtlas");
                }
            }
        }

    }
}
