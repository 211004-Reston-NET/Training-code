//Encapsulation with IIFE
let Outer = 
(
    () =>
    {
        let count = 0;

        return function Inner()
        {
            return count +=1;
        }
    }
)();

// IIFE with encapsulation that hides currentMoney but you have access to one of its function called withdrawl
let bankAccount = money => (function(copyMoney) {
    let currentMoney = copyMoney; //This essentially makes the variable have a private access modifier

    return {
        withdrawl: function(amount) {
            if (currentMoney >= amount) {
                currentMoney -= amount;
                return currentMoney;
            } else {
                return "Insufficient money";
            }
        },
        deposit: function(amount) {
            currentMoney += amount;
            return currentMoney;
        }
    }
})(money);