using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovCocktail : missile {
    void Start()
    {
        this.onHitTraget += Explord;
    }
    void Update()
    {
        if (traget == null)
        {
            Destroy(gameObject);
            onHitTraget();
            return;
        }
        float rotateZ= 360-AngleGetter.GetAnglefromZero3D(traget.transform.position - transform.position)+90;
        transform.eulerAngles = new Vector3(0,0,rotateZ);
        base.Update();
    }
    public void Explord()
    {
        Instantiate(EffectionTable.main.effections[11], transform.position, transform.rotation);
    }
}
