
action();


function action() {

var x=700,y=500,r=0.01;
var dx=200,dy=10,k=1;
var height = document.documentElement.scrollHeight-51;
var width = document.documentElement.scrollWidth-51;

	


 var interval = setInterval(pohyb,30);


function pohyb() {

k+=0;
x+=k*dx;
y+=k*dy;

//gravitace
dy-=0.1;

dx-=dx*r;
dy-=dy*r;



if(x<0 || x>width) {

if(x<0) {
	x=0;
}
else {
	x=width;
}
	dx*=-0.8;
}



if(y<0 || y>height) {

if(y<0) {
	y=0;
}
else {
	y=height;
}

	dy*=-0.8;
}



	 document.getElementById("kruh").style = "position: absolute;bottom:"+y+"px;"+"left:"+x+"px";

}
}







