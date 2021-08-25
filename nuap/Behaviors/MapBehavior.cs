using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using nuap.Models;

namespace nuap.Behaviors
{
    public class MapBehavior : BindableBehavior<Map>
    {
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<Address>), typeof(MapBehavior), null, BindingMode.Default, propertyChanged: ItemsSourceChanged);

        public IEnumerable<Address> ItemsSource
        {
            get => (IEnumerable<Address>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MapBehavior behavior)) return;
            behavior.AddPins();
        }

        private void AddPins()
        {
            var map = AssociatedObject;
            for (int i = map.Pins.Count - 1; i >= 0; i--)
            {
                map.Pins[i].Clicked -= PinOnClicked;
                map.Pins.RemoveAt(i);
            }

            var pins = ItemsSource.Select(x =>
            {
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(Double.Parse(x.Latitude), Double.Parse(x.Longitude)),
                    Label = x.Addres,
                    Address = x.Neighborhood,
                };

                pin.Clicked += PinOnClicked;
                return pin;
            }).ToArray();
            foreach (var pin in pins)
                map.Pins.Add(pin);
        }

        private void PinOnClicked(object sender, EventArgs eventArgs)
        {
            var pin = sender as Pin;
            if (pin == null) return;
            var viewModel = ItemsSource.FirstOrDefault(x => x.Addres == pin.Label);
            if (viewModel == null) return;
            //viewModel.Command.Execute(null); // TODO We are going to implement this later ;)
        }
    }
}