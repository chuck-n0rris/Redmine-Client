namespace Redmine.Client.Ui.Mvvm
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Provides extension methods for the NotifyingModelBase type
    /// </summary>
    public static class NotifyingModelBaseExtensions
    {
        /// <summary>
        /// Observes change notifications to a property.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="instance">The object being extended by the operation</param>
        /// <param name="expression">The expression that identifies the target for the operation</param>
        /// <param name="onChange">Call back handler when the property changes</param>
        public static void ObserveProperty<TInstance, TMember>(this TInstance instance,
                                                                Expression<Func<TInstance, TMember>> expression,
                                                                Action onChange)
            where TInstance : NotifyingModelBase
        {
            instance.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == instance.GetMemberName(expression))
                {
                    onChange();
                }
            };
        }

        /// <summary>
        /// Sets the value of a member and raises the property changed event.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="instance">The object being extended by the operation</param>
        /// <param name="expression">The expression that identifies the target for the operation</param>
        /// <param name="value">The value.</param>
        /// <param name="additionalNotificationsExpression">Optional expression that identifies additional change notifications that must be raised.</param>
        public static void SetValueAndRaisePropertyChanged<TInstance, TMember>(this TInstance instance,
                                                                                     Expression<Func<TInstance, TMember>> expression,
                                                                                     TMember value,
                                                                                     params Expression<Func<TInstance, TMember>>[] additionalNotificationsExpression)
            where TInstance : NotifyingModelBase
        {
            var newVal = instance.GetValue(expression);
            if ((ReferenceEquals(newVal, null) && ReferenceEquals(value, null))
                || (!ReferenceEquals(newVal, null) && newVal.Equals(value))) return;
            
            instance.SetValueAndRaisePropertyChanged(instance.GetMemberName(expression), value);
            if(additionalNotificationsExpression != null)
            {
                Array.ForEach(additionalNotificationsExpression, selector => instance.OnPropertyChanged(instance.GetMemberName(selector)));
            }
        }

        /// <summary>
        /// Sets properties with will trascking.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="expressions">The expressions.</param>
        public static void SetTrackingProperties<TInstance, TMember>(this TInstance instance, 
                                                                     params Expression<Func<TInstance, TMember>>[] expressions)
            where TInstance : TrackingChangesModel
        {
            var props = expressions.Select(it => instance.GetMemberName<TInstance, TMember>(it)).ToArray();
            instance.SetTrackingProperties(props);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="instance">The object being extended by the operation</param>
        /// <param name="expression">The expression that identifies the target for the operation</param>
        /// <returns>The value of the member identified by <paramref name="expression"/> if it has been set otherwise the default value for the object type</returns>
        public static TValue GetValue<TInstance, TValue>(this TInstance instance, Expression<Func<TInstance, TValue>> expression)
            where TInstance : NotifyingModelBase
        {
            var result = instance.GetValue(instance.GetMemberName(expression));
            return result != null ? (TValue)result : default(TValue);
        }

        /// <summary>
        /// Gets the name of the member.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TMember">The type of the member.</typeparam>
        /// <param name="instance">The object being extended by the operation</param>
        /// <param name="expression">The expression that identifies the target for the operation</param>
        /// <returns>The name of the member identified by <paramref name="expression"/></returns>
        public static string GetMemberName<TInstance, TMember>(this TInstance instance, Expression<Func<TInstance, TMember>> expression)
            where TInstance : NotifyingModelBase
        {
            if(instance == null)
            {
                return null;
            }

            var memberExpression = expression.Body as MemberExpression;
            if(memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if(unaryExpression != null)
                {
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
            }

            return memberExpression.Member.Name;
        }
    }
}
