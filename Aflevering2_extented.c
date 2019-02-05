#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <string.h>

#define HOURS	(60*60)
#define MINUTES	60

int main (void){
	long Input_sec = 0, sekunder = 0, minutter = 0, timer = 0;
	printf("Input secounds: ");
	scanf(" %li", &Input_sec);
	timer = Input_sec/HOURS;
	minutter = (Input_sec%HOURS)/MINUTES;
	sekunder = (Input_sec%MINUTES);
	printf("%li%s%s%s%li%s%s%s%li%s%s\n\n", timer, (timer ? "" : "\b"), (timer ? (timer>1 ? " timer" : " time") : ""), (timer && minutter && sekunder ? ", " : (timer && minutter || timer && sekunder ? " og " : "")), minutter, (minutter ? "" : "\b"), (minutter ? (minutter>1 ? " minutter" : " minut") : ""), (minutter && sekunder ? " og " : ""), sekunder, (sekunder ? "" : "\b"), (sekunder ? (sekunder>1 ? " sekunder" : " sekund") : ""));
	return EXIT_SUCCESS;
}