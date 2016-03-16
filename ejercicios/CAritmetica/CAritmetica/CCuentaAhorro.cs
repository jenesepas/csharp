class CCuentaAhorro : CCuenta {
    private double coutaMantenimiento;
    
    public CCuentaAhorro()
        {}

    public CCuentaAhorro(string nom, string cta, double sald, double ti,double mant): base(nom,cta,sald,ti)
    {
        //asignarCoutaManten(mant);
        this.coutaManten = mant;
    }

    public double coutaManten
    {
        get
        {
            return coutaMantenimiento;
        }
        set
        {
            if (value < 0)
            {
                System.Console.WriteLine("Error: cantidad negativa.");
                return;
            }
            coutaMantenimiento = value;            
        }
    }
    /*
    public void asignarCoutaManten(double canti)
    {
        if (canti < 0)
        {
            System.Console.WriteLine("Error: cantidad negativa.");
            return;
        }
        coutaMantenimiento = canti;
    }
    public double obtenerCoutaManten()
    {
        return coutaMantenimiento;
    }
     */
    public void muestraCta()
    {
        base.muestraCta();
        System.Console.WriteLine("Couta Mant.: " + this.coutaManten);
        //System.Console.WriteLine("Couta Mant.: " + this.obtenerCoutaManten());
    }
}