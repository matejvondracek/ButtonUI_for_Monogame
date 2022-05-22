# ButtonUI_for_Monogame
This is a small library I made because I couldn't find anything simmilar. 
My problem with other libraries/frameworks for Monogame was that they were too complicated for what I needed or there was no documentation, therefore I created my own.
I named it ButtonUI because almost every object uses button as a starting point and I've found that quite amusing.

Feel free to use it for whatever you need! :)

## How to use it?
For example you want to create simple button. 
In your game1 class make new variable - Button. 
After you create it, you will have to update it in Update method and draw it in Draw method.

If you wanted to make multiple object it would take a lot of space to update and draw every single of them.
You can use UIGroup which is basically a list. 
Just add in it everything you need and then update and draw all of them with single statement.

## What it can do
- Button
- Label - to display text
- ToggleButton - switches between two states (on, off)
- TextBox - user can write in simple text
- ValueBox - user can increase or decrease a certain value
- Slider - it's utilization is same as ValueBox but looks better and it is faster to choose a value

## What it can't do
It can't generate textures - you will have to make your own and past it in in an array. 
Buttons don't generate events - for now you will have to check IsPressed() every loop after you update it.
Maybe I will fix these drawbacks in the future but I can't promise it.

I hope you will find it usefull ;)
