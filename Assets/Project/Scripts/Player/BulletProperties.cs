using UnityEngine;

public class BulletProperties
{
   
    private float baseDamage = 0.3f;
    private int bouncesAmount = 1;
    static private float poissonChance = 0.0f;
    private float poissonDamage = 0.1f;
    private bool applyPoissonDamage = false;
    static private float slowChance = 0.0f;
    private float slowAmount = 0.1f;
    private bool applySlow = false;
    static private float criticalChance = 0.0f;
    private float criticalMultiplier = 1.25f;
    private bool applyCriticalDamage = false;

    public float BaseDamage {get { return baseDamage; } set { baseDamage = value;}}
    public int BouncesAmount {get {return bouncesAmount;} set {bouncesAmount = value;}}
    public float PoissonChance {get { return poissonChance; } set { poissonChance = value;}}

    public float PoissonDamage {get { return poissonDamage; } set { poissonDamage = value;}}

    public bool ApplyPoissonDamage {get { return applyPoissonDamage; } set { applyPoissonDamage = value;}}

    public float SlowChance {get { return slowChance; } set { slowChance = value;}}

    public float SlowAmount {get { return slowAmount; } set { slowAmount = value;}}

    public bool ApplySlow {get { return applySlow; } set { applySlow = value;}}

    public float CriticalChance {get { return criticalChance; } set { criticalChance = value;}}

    public float CriticalMultiplier {get { return criticalMultiplier; } set { criticalMultiplier = value;}}

    public bool ApplyCriticalDamage {get { return applyCriticalDamage; } set { applyCriticalDamage = value;}}


    public BulletProperties generateRandom(){

        BulletProperties bp = new BulletProperties();

        bp.baseDamage = this.baseDamage;
        bp.bouncesAmount = this.bouncesAmount;
        bp.applyPoissonDamage = Random.Range(0.0f, 1.0f) <= poissonChance;
        bp.poissonDamage = this.poissonDamage;
        bp.slowAmount = this.slowAmount;
        bp.applySlow = Random.Range(0.0f, 1.0f) <= slowChance;
        bp.criticalMultiplier = this.criticalMultiplier;
        bp.applyCriticalDamage = Random.Range(0.0f, 1.0f) <= criticalChance;       

        return bp;

    }

}
