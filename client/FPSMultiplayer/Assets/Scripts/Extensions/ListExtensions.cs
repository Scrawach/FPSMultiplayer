using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtensions
    {
        public static TObject AddTo<TObject>(this TObject self, List<TObject> objects)
        {
            objects.Add(self);
            return self;
        }
    }
}