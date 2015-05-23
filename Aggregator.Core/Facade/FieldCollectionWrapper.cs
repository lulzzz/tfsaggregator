﻿namespace Aggregator.Core.Facade
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.TeamFoundation.WorkItemTracking.Client;

    public class FieldCollectionWrapper : IFieldCollectionWrapper
    {
        private FieldCollection fields;
        public FieldCollectionWrapper(FieldCollection fieldCollection)
        {
            fields = fieldCollection;
        }

        public IFieldWrapper this[string name]
        {
            get
            {
                return new FieldWrapper(fields[name]);
            }
            set
            {
                //Do nothing - this is here for unit testing purposes.
                //We don't actually want to add fields in our app code
            }
        }

        public IEnumerator<IFieldWrapper> GetEnumerator()
        {
            return ((IEnumerable)fields).Cast<Field>().Select(f => (IFieldWrapper)new FieldWrapper(f)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}