using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    protected int basehp = 100;
    public int GetmaxHP(){
        return basehp + STR*50;
    }
    public void SetmaxHP(int maxhp){  //called on newgame
        basehp = maxhp;
    }
    protected int currenthp = 100;
    public int GetcurrHP(){
        return currenthp;
    }
    public void SetcurrHP(int newhp){
        currenthp = newhp;
    }
    /*
    protected int basemp = 100;
    public int GetmaxMP(){
        return basemp + INT*50;
    }
    public void setmaxMP(int maxmp){ //called on newgame
        basemp = maxmp;
    }
    protected int currentmp = 100;
    public int GetcurrMP(){
        return currentmp;
    }
    public void SetcurrMP(int newmp){
        currentmp = newmp;
    }
    */
    protected int STR = 0;
    public int GetSTR(){
        return STR;
    }
    public void SetSTR(int newSTR){
        STR = newSTR;
    }
    public void addStr(){
        if (STR < 100){
            STR += 1;
        }else{
            return;
        }
    }
    protected int AGI = 0;
    public int GetAGI(){
        return AGI;
    }
    public void SetAGI(int newAGI){
        AGI = newAGI;
    }
    public void addAgi(){
        if (AGI < 100){
            AGI += 1;
        }else{
            return;
        }
    }
    /*
    protected int INT = 0;
    public int GetINT(){
        return INT;
    }
    public void addInt(){
        if (INT < 198){
            INT += 1;
        }else{
            return;
        }
    }
    */
    protected int SP = 0;
    public int GetSP(){
        return SP;
    }
    public void SetSP(int newsp){
        SP = newsp;
    }
    protected int Level = 1;
    public int GetLevel(){
        return Level;
    }
    public void SetLevel(int newlvl){
        Level = newlvl;
    }
    protected int currentEXP = 0;
    public int GetCurrentEXP(){
        return currentEXP;
    }
    public void SetCurrentEXP(int newexp){
        currentEXP = newexp;
    }
    protected int nextlevelexp = 1;
    public int Getnextlevelexp(){
        return nextlevelexp;
    }
    public void SetnextlevelEXP(int newexp){
        nextlevelexp = newexp;
    }
    protected int gold = 0;
    public int GetGold(){
        return gold;
    }
    public void SetGold(int newgold){
        gold = newgold;
    }
    protected int BaseDamage = 2;
    public int GetBaseDamage(){
        return BaseDamage;
    }
    public void SetBaseDamage(int newbasedmg){
        BaseDamage = newbasedmg;
    }
    protected int specialDamage = 2;
    public int GetSpecialDamage(){
        return specialDamage;
    }
    public void SetSpecialDamage(int newspecdmg){
        specialDamage = newspecdmg;
    }
    protected float attackspeed = 2.0f;
    public float GetAttackSpeed(){
        return attackspeed + (AGI*4/100);
    }
    public void SetAttackSpeed(int newatkspd){
        attackspeed = newatkspd;
    }
    protected float specialmeter = 0f;
    public float GetSpecialMeter(){
        return specialmeter;
    }
    public void ResetSpecialMeter(){
        specialmeter = 0f;
    }
    protected int Potions = 10;

    public int GetPotions(){
        return Potions;
    }
    public void SetPotions(int curpots){
        Potions = curpots;
    }
    public void GetPotions(int amount){
        Potions += amount;
    }
    public void EnemyHit(){
        specialmeter += 10;
    }
    protected Memoria currentMemoria;
    public Memoria GetCurrentMemoria(){
        return currentMemoria;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null){ //singleton
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    static PlayerData instance;
    public static PlayerData GetInstance(){
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (calculatenextlevelexp(Level)<=currentEXP){
            levelup();
        }
    }
    int calculatenextlevelexp(int level){
        nextlevelexp = level * 2;
        return nextlevelexp;
    }
    void earnexp(int exp){
        currentEXP += exp;
    }
    void levelup(){
        currentEXP = 0;
        Level += 1;
        SP += 5;
        nextlevelexp = calculatenextlevelexp(Level);
    }
    public void heal(){
        if(Potions > 0){
            currenthp += 20 + 10*STR;
            Potions -= 1;
            if (currenthp > GetmaxHP()){
                currenthp = GetmaxHP();
            }
        }
    }
    public void RespawnHere(){
        gold -= Level*10;
        basehp = GetmaxHP();
        SetmaxHP(basehp);
        SetcurrHP(basehp);
    }
    public void RespawnTown(){
        basehp = GetmaxHP();
        SetmaxHP(basehp);
        SetcurrHP(basehp);
    }
}
