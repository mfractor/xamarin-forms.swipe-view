﻿using System;

namespace SwipeViewSamples.Attributes
{
    /// <summary>
    /// Apply the design time binding context attribute to your code-behind class to inform tools of your intended runtime binding context.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DesignTimeBindingContextAttribute : Attribute
    {
        /// <summary>
        /// Specifies the design time binding context using a fully qualified type name.
        ///
        /// For example: MyApp.ViewModels.LoginViewModel.
        /// </summary>
        /// <param name="typeName">The fully qualified type name for the design time binding context.</param>
        public DesignTimeBindingContextAttribute(string typeName)
        {
        }

        /// <summary>
        /// Specifies the design time binding context using typeof().
        ///
        /// For example: typeof(LoginViewModel)
        /// </summary>
        /// <param name="type">The <see cref="System.Type"/> for the design time binding context, using typeof().</param>
        public DesignTimeBindingContextAttribute(Type type)
        {
        }
    }
}