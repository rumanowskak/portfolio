function [p] = get_init_p(J_func, x, y, dt)
    p = [0.01, 0.01];
    min_J = inf;
    for p1 = logspace(-2, 2, 50)
        for p2 = logspace(-2, 2, 50)
            J = J_func(p1, p2, x, y, dt);
            if J < min_J
                min_J = J;
                p = [p1, p2];
            end
        end 
    end
end