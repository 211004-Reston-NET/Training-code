//=================== Variables ===================

console.log("==== Variable ====");

//Anything you assign to a variable you just created will have that datatype
//In this case, s1 will only hold strings
let s1 = "hello";
let s2:string; //C# equivalent, string s2;
s2 = "world";

//console.log(s1);
//s1 = 5; Note: TS will give a compiler error but will still run in JS perfectly fine since it is not type safety 
//console.log(s1);

console.log(`${s1} ${s2}`);

//ANY - the default type of a declared variable if not implicity or explicity given a datatype
let a1;
a1 = "hello";
a1 = 5;
a1 = null;
a1 = false;

//Number
let n1:number;
n1 = 10;

//You can supply multiple types to a single variable
let m1: string | number | boolean;
m1 = "string";
m1 = 10;
m1 = true;

//DO NOT use void or never as datatypes in a variable, void is for function return types
//Never is used fo error handling

//NULL and UNDEFINED
let nul1:null; //undefined if you didn't set a value to something
let nul2 = null; //null is the meaning of lack of value
console.log(typeof(nul1));
console.log(typeof(nul2));

//Array
let arry1: any[];
arry1 = ["string", true, 10];
arry1.push(null); //Adds an element to your array
console.log(arry1);

let arry2: (string | number)[];
arry2 = ["string", 10, 5, 2];
// arry2.push(true);

let arry3: string | number[];
arry3 = "string";
arry3 = [10 , 6 , 3];
// arry3 = [10, "string"]; Cannot be both

//TUPLE - It is an array but a fixed position of datatypes
let tup1: [number, string, string, boolean];
tup1 = [10, "string", "string", true];
// tup1 = ["string", 10, "string", false];
console.log(tup1);
tup1.push(6,"string", "string", false);
console.log(tup1);

//ENUM - enumeration, specified set of constants. Mostly used to be easier to read your code
enum Engine
{
    Off = 0,
    On = 1,
    Accel = 2
}

let engineState = 0;

if (engineState == Engine.Off) {
    console.log("Engine is Off");
}

if (engineState == 0) {
    console.log("Engine is Off");
}

//===================== Functions ===================== 
console.log("==== Function ====");

function Print(para1:string, para2:string) {
    console.log(`${para1} ${para2}`);
}

Print("Hello", "World");

function Print2(para1:string, para2:string) : string {
    return `${para1} ${para2}`;
}

console.log(Print2("Hello", "World"));

//===================== Classes and Objects ===================== 
console.log("==== Classes and Objects ====");

class Pokemon {

    name:string;
    move:string;
    health:number;
    attack:number;

    constructor(p_name:string="", p_move:string="", p_health:number=0, p_attack:number=0) {
        this.name = p_name;
        this.move = p_move;
        this.health = p_health;
        this.attack = p_attack;
    }

    //We can do method overloading by using optional or default parameters
    catchPhrase(p_say:string="")
    {
        console.log("Gotta catch em all");
        console.log(p_say);
    }
}

let poke:Pokemon;
poke = new Pokemon("Pikachu", "thunderbolt", 100, 60);
poke.catchPhrase();
poke.catchPhrase("Pikachu nooooooo");

class Pikachu extends Pokemon 
{

    constructor() {
        super();
    }

    //Method overriding
    catchPhrase(p_say:string="")
    {
        console.log(`${p_say} That's a catch phase!`);
    }
}

let poke2: Pikachu = new Pikachu();
poke2.catchPhrase("Pika PIIII");

interface ThunderType
{
    type:string;
    thunder?:string; //You can make properties optional
    weakness:string[];

    thunderBolt(); //Function that doesn't have any implementation
    run?(); //You can make functions optional
}

class Zapdos implements ThunderType {

    type:string;
    weakness:string[];

    constructor(parameters) {
        
    }

    thunderBolt()
    {

    }
}
