namespace ExploreUserContextCommon
{
    public class InstanceActivator
    {
        #region Publics
        public static T GetInstance<T>()
        {
            return (T) GetInstance(typeof(T));
        }

        public static object GetInstance(Type t)
        {
            if(t == null) throw new ArgumentNullException("t");
            if(!t.IsInterface) throw new ArgumentException(string.Format("'{0}' is not an interface.", t.FullName));

            object oFacade;

            // try local

            // identify assembly
            string strAssemblyName = t.Assembly.FullName;
            strAssemblyName = strAssemblyName.Replace("Common", "Logic");

            // identify type
            string strTypeFullName = t.FullName;
            strTypeFullName = strTypeFullName.Replace("Common", "Logic");
            strTypeFullName = strTypeFullName.Remove(strTypeFullName.LastIndexOf('.') + 1, 1); // remove first char of interface name ('I')

            // get type
            Type typeImplementing;
            try
            {
                typeImplementing = Type.GetType(strTypeFullName + ", " + strAssemblyName, true);
            }
            catch(FileNotFoundException)
            {
                throw new TypeLoadException(string.Format("Assembly '{0}' not found.", strAssemblyName));
            }
            catch(TypeLoadException)
            {
                throw new TypeLoadException(string.Format("Type '{0}' in Assembly '{1}' not found.", strTypeFullName, strAssemblyName));
            }

            if(typeImplementing.GetInterface(t.FullName) == null)
            {
                throw new TypeLoadException(string.Format("Type '{0}' does not implement Interface '{1}'.", strTypeFullName, t.FullName));
            }

            oFacade = CreateInstance(typeImplementing);

            return oFacade;
        }

        public static object CreateInstance(Type type)
        {
            try
            {
                return Activator.CreateInstance(type, true);
            }
            catch(Exception e)
            {
                throw new ApplicationException($"Creating an instance of type '{type}' failed.", e);
            }
        }
        #endregion
    }
}