﻿using System.Reflection;

namespace XCRS.Core.Utility
{
    public abstract record EnumerationUtil<T> : IComparable<T> where T : EnumerationUtil<T>
    {
        protected static readonly Lazy<Dictionary<int, T>> AllItems;
        protected static readonly Lazy<Dictionary<string, T>> AllItemsByName;

        static EnumerationUtil()
        {
            AllItems = new Lazy<Dictionary<int, T>>(() =>
            {
                return typeof(T)
                    .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                    .Where(x => x.FieldType == typeof(T))
                    .Select(x => x.GetValue(null))
                    .Cast<T>()
                    .ToDictionary(x => x.Value, x => x);
            });
            AllItemsByName = new Lazy<Dictionary<string, T>>(() =>
            {
                var items = new Dictionary<string, T>(AllItems.Value.Count);
                foreach (var item in AllItems.Value)
                {
                    if (!items.TryAdd(item.Value.DisplayName, item.Value))
                    {
                        throw new Exception(
                            $"DisplayName needs to be unique. '{item.Value.DisplayName}' already exists");
                    }
                }
                return items;
            });
        }

        protected EnumerationUtil(int value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        public int Value { get; }
        public string DisplayName { get; }
        public override string ToString() => DisplayName;

        public static IEnumerable<T> GetAll()
        {
            return AllItems.Value.Values;
        }

        public static int AbsoluteDifference(EnumerationUtil<T> firstValue, EnumerationUtil<T> secondValue)
        {
            return Math.Abs(firstValue.Value - secondValue.Value);
        }

        public static T FromValue(int value)
        {
            if (AllItems.Value.TryGetValue(value, out var matchingItem))
            {
                return matchingItem;
            }
            throw new InvalidOperationException($"'{value}' is not a valid value in {typeof(T)}");
        }

        public static T FromDisplayName(string displayName)
        {
            if (AllItemsByName.Value.TryGetValue(displayName, out var matchingItem))
            {
                return matchingItem;
            }
            throw new InvalidOperationException($"'{displayName}' is not a valid display name in {typeof(T)}");
        }

        public int CompareTo(T? other) => Value.CompareTo(other!.Value);
    }
}