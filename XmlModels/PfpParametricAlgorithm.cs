namespace PfpReader.Models
{
    public enum PfpParametricAlgorithm
    {
        None,
        CAM,           //RwBased X,Y stretch
        Script,        //Script based X,Y stretch
        BendExpress,   //Bendexpress based XY Stretch
        Automatic,     //Automatic calculation of program sequece from a input geometry
        AutomaticNoGeo, //Automatic calculation of program sequence and geometry from a set of parameters
        Autometric,    //Reprogramming of mother program sequence on input child geometry
        AutometricNoGeo //Reprogramming of mother program sequence and geometry from a set of parameters
    }
}