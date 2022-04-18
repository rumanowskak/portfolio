%projekt2
%optymalizacja
f=@(x) cos(x);
x0=1;
%interesuje nas gdzie jest minimum i to zwraca fmicon
 xmin=fmincon(f,x0);
 
 f2=@(x)cos(x(1))+cos(x(2)-0.5);
 x02=[1;1];
 xmin2=fmincon(f2,x02,[],[],[],[],[0.1;0.1],[]);