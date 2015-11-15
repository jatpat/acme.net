namespace ACME.Protocol.Asn1
{
    public class AlgorithmIdentifier : Sequence
    {
        public AlgorithmIdentifier(string algorithm) : base(new ObjectIdentifier(algorithm), new Null())
        {            
        }    
    }
}