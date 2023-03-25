// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using GP.AzureDevOps.Business.Configuration;

namespace GP.AzureDevOps.Business
{
    public abstract class BaseBusiness 
    {
        protected AzureConfig Config = new AzureConfig();
    }
}
