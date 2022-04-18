%zadanie1

Dane= readtable('dane66.csv');

tt=Dane(:,1);
xt=Dane(:,2);
yt=Dane(:,3);
t=table2array(tt);
x=table2array(xt);
y=table2array(yt);
N=length(x);
tspan=t(1)-t(2);
%metoda 1 - jawna metoda Eulera
xe=zeros(N,1);
xe(1)=x(1);
min_p = [0.01, 0.01];
min_Jx = inf;
for p1 = 0.001 : 0.001 : 1
   for p2 = 0.001 : 0.001 : 1
       Jx = calculate_Jx_four(p1, p2, x, y, tspan);
       if Jx < min_Jx
           min_Jx = Jx;
           min_p = [p1, p2];
       end
   end
end
p1 = min_p(1);
p2 = min_p(2);
disp(p1);
disp(p2);
calculate_Jx_four(p1, p2, x, y, tspan)
[q]=fmincon(@(q) calculate_Jx_four(q(1), q(2), x, y, tspan), ...
            [p1,p2], [1, 1], 100);
disp(q(1));
disp(q(2));
f = @(x, y) p1*x - p2*x*y;
for i=2:N
    % xe(i)=xe(i-1)+ (q(1)*xe(i-1)-q(2)*xe(i-1)*y(i-1))*tspan;
    A = (q(1) - q(2)*y(i));
    xe(i)=(eye(1) - 1/2*A*tspan)\(xe(i-1)+...
        1/2*f(xe(i-1), y(i-1))); 
end
Jx = sum((xe(2:end)-x(2:end)).^2);
hold on
plot(t, x, 'b');
plot(t, y, 'k--');
plot(t, xe, 'r');
hold off
disp(Jx);
