# This is a comment to add more information to your code
# echo Comment
echo Hello # <- This is a echo to display Hello
echo World

msg="Hello World"

echo $msg

echo What is your name?
read userInput
echo "Hello $userInput, Welcome to Programming!"

# Control FLow
# Types of loops
# For loop - They will repeat something a set number of times
for var in 1 2 3 4 5
do
	echo $var
	echo This variable currently holds: $var
done

for i in {1..10..1} #{starting number.. end number..incrementing number}
do
	echo $i
done

for words in Hello World Test Hi What
do
	echo $words
done

# While loops - they will repeat something until the condition isn't satisfied anymore
condition="true"

while [ "$condition" != "false" ]
do
	echo "Do you want to repeat? (true or false)"
	read condition
	echo "You typed: $condition"

	if [ "$condition" == "duck" ]
	then
		echo "quack"
	else
		echo "not a duck"
	fi
done

