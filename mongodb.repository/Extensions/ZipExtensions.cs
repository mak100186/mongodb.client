namespace mongodb.repository.Extensions
{
    using Models;

    public static class ZipExtensions
    {
        public static string ToJsonString(this Zip zip)
        {
            return $"zip : {{ \n\tid: {zip.Id}, \n\tcity : {zip.City}, \n\tzip : {zip.ZipCode}, \n\tloc : {{ \n\t\tx : {zip.Location.X}, \n\t\ty : {zip.Location.Y} \n\t}}, \n\tstate : {zip.State}, \n\tpop : {zip.Population} \n}}";
        }
    }
}