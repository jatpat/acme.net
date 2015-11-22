using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;
using Oocx.ACME.Common;
using Oocx.ACME.Services;

namespace Oocx.ACME.Console
{
    public class Options
    {
        [Option('s', "server", Default = "https://acme-v01.api.letsencrypt.org", HelpText = "Specifies the ACME server from which to request certificates.")]
        public string AcmeServer { get; set; }
        
        [Value(0, HelpText = "The names of the domains for which you want to request a certificate.", Required = true, MetaName = "domains")]
        public IEnumerable<string> Domains { get; set; }

        [Option('a', "acceptTOS", HelpText = "Accept the terms of service of the ACME server")]
        public bool AcceptTermsOfService { get; set; }

        [Option('i', "ignoreSSLErrors", HelpText = "Ignore SSL certificate errors for the HTTPS connection to the ACME server (useful for debugging messages with fiddler)")]
        public bool IgnoreSSLCertificateErrors { get; set; }

        [Option('v', "verbosity", HelpText = "Configures the log level (verbose, info, warning, error, disabled).", Default = LogLevel.Info)]
        public LogLevel Verbosity { get; set; }

        [Option('p', "password", HelpText = "The password used to protect the generated pfx file")]
        public string PfxPassword { get; set; }

        [Option('l', "accountKeyContainerLocation", HelpText = "The base path or key container location that is used to store the acme registration key. 'user' will store the key in a user protected key container, 'machine' uses a machine container. All other inputs will be used as directory name.")]
        public string AccountKeyContainerLocation { get; set; }

        [Option('n', "accountKeyName", HelpText = "The name of the key file or key container used to store the acme registration key.", Default = "acme-key")]
        public string AccountKeyName { get; set; }

        [Option('c', "challengeProvider", HelpText = "The type of web server integration to use for ACME challenges. Supported types are: 'manual' (no integration), 'iis-http-01' (IIS with http-01 challenge)", Default = "iis-http-01")]
        public string ChallengeProvider { get; set; }

        [Option('s', "serverConfigurationProvider", HelpText = "The type of web server configuration to use to install and configure certificates. Supported types are: 'manual' (no integration), 'iis' (installs certificates to localmachine\\my and configures IIS bindings)", Default = "iis")]
        public string ServerConfigurationProvider { get; set; }

        [Option('w', "iisWebSite", HelpText = "The IIS web site that should be configured to use the new certificate (used with --serverConfigurationProvider iis). If you do not specifiy a web site, the provider will try to find a matching site with a binding for your domain.")]
        public string IISWebSite { get; set; }

        [Option('b', "iisBinding", HelpText = "The IIS binding that should be configured to use the new certificate. Syntax: ip:port:hostname, for example '*:443:www.example.com' (used with --serverConfigurationProvider iis). If you do not specifiy a binding, the provider will try to find a matching binding. It will create a binding if no matching binding exists.")]
        public string IISBinidng { get; set; }
    }    
}