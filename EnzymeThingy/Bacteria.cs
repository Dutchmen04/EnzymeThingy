namespace EnzymeThingy;

public class Bacteria
{
    public float d_p { get; set; }
    public float m { get; set; }
    public float t_l { get; set; }
    public float d_r { get; set; }

    public Bacteria(float dP, float m, float tL, float dR)
    {
        d_p = dP;
        this.m = m;
        t_l = tL;
        d_r = dR;
        
    }
    
    
}