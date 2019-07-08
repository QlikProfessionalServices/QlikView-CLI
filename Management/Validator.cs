namespace QlikView_CLI.Management
{
    internal class Validator
    {
        public void checkConnection(ref QMS something)
        {
            if (something == null)
            {
                if (Globals.VariableStore.QVConnection != null)
                {
                    something = Globals.VariableStore.QVConnection;
                }
                else
                {
                    throw new System.ArgumentException("Connect to QlikView Server without using -Passthru or specify a -Connection and try again", "Connection");
                }
            }
        }
    }
}
