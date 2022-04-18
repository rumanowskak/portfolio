function [Jy, y_approx] = calculate_Jy_euler_imp(p3, p4, x_real, y_real, dt)
% p1, p2 parametry funkcji
% f
% x_init - wartość początkowa x
% y - wektor wartości dokładnych y

N = length(y_real);
y_approx = zeros(N, 1);
y_approx(1) = y_real(1);

for i = 2:N
    A = (p3*x_real(i) - p4);
    y_approx(i)=y_approx(i-1)/(1-A*dt); 
end

diff = abs(y_real - y_approx);
Jy = sum(diff(2:end));

end

