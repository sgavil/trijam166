using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps 
{
    public enum POWER_UPS_OPTIONS{

        INCREMENT_SHOOTER,
        INCREMENT_SHOOTER_SPEED,
        INCREMENT_BULLETS_PER_SHOT,
        INCREMENT_BOUNCES_ON_IMPACT,
        INCREMENT_BASE_DAMAGE, 
        INCREMENT_POISSON_CHANCE,
        INCREMENT_POISSON_DAMAGE,
        INCREMENT_SLOW_CHANCE,
        INCREMENT_SLOW_AMOUNT, 
        INCREMENT_CRITICAL_CHANCE,
        INCREMENT_CRITICAL_MULTIPLIER, 

        END


    }

    public POWER_UPS_OPTIONS generateRandomPowerUp(){

        POWER_UPS_OPTIONS powerUp = (POWER_UPS_OPTIONS)Random.Range(0, (int)POWER_UPS_OPTIONS.END);

        BulletProperties bp = new BulletProperties();

        const float DEACTIVATED = 0.0f;

        switch(powerUp){

            case POWER_UPS_OPTIONS.INCREMENT_POISSON_DAMAGE:
            if(bp.PoissonChance == DEACTIVATED){
                return generateRandomPowerUp();
            }
            break;

            case POWER_UPS_OPTIONS.INCREMENT_SLOW_AMOUNT:
                if(bp.SlowChance == DEACTIVATED){
                    return generateRandomPowerUp();
                }
            break;

            case POWER_UPS_OPTIONS.INCREMENT_CRITICAL_MULTIPLIER:
            if(bp.CriticalChance == DEACTIVATED){
                return generateRandomPowerUp();
            }
            break;

        }

        return powerUp;     

    }
}

public abstract class PowerUp{

    protected string name;

    public string toString {get { return name; }}

    public abstract void apply();


}

public class IncrementShooter : PowerUp
{

    public IncrementShooter(){

        name = "+1 Shooter"; 

    } 

    public override void apply()
    {
        Player.Instance.incrementShooter();
    }

}

public class IncrementShooterSpeed : PowerUp
{

    public IncrementShooterSpeed(){

        name = "+25% shooters rotation speed"; 

    } 

    public override void apply()
    {
        Player.Instance.incrementShooterRotationSpeed(0.70f);
    }

}

public class IncrementBulletsPerShot : PowerUp {

    public IncrementBulletsPerShot(){

        name = "+1 Bullets/shot"; 

    } 

    public override void apply()
    {
        Player.Instance.incrementBulletsPerShot();
    }

}

public class IncrementBouncesOnImpact : PowerUp {

    public IncrementBouncesOnImpact(){

        name = "+1 Bounces on bullet impact"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.BouncesAmount++;
    }

}

public class IncrementBaseDamage : PowerUp {

    public IncrementBaseDamage(){

        name = "+0.50 damage on hit"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.BaseDamage += 0.5f;
    }

}

public class IncrementPoissonChance : PowerUp {
    public IncrementPoissonChance(){

        name = "+10% chance to apply poisson on bullet hit"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.PoissonChance += 0.10f;
    }

}

public class IncrementPoissonDamage : PowerUp {
    public IncrementPoissonDamage(){

        name = "+0.2 poisson damage"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.PoissonDamage += 0.20f;
    }

}

public class IncrementSlowChance : PowerUp {
    public IncrementSlowChance(){

        name = "+10% chance to apply slow on bullet hit"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.SlowChance += 0.10f;
    }

}

public class IncrementSlowAmount : PowerUp {
    public IncrementSlowAmount(){

        name = "+10% enemies movement slowness on slow"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.SlowAmount += 0.10f;
    }

}

public class IncrementCriticalChance : PowerUp {
    public IncrementCriticalChance(){

        name = "+10% chance to apply critical strike on bullet hit"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.CriticalChance += 0.10f;
    }

}

public class IncrementCriticalDamageMultiplier : PowerUp {
    public IncrementCriticalDamageMultiplier(){

        name = "+20% critical damage"; 

    } 

    public override void apply()
    {
        Bullet.BaseProperties.CriticalMultiplier += 0.20f;
    }

}