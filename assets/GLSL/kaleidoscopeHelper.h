// Copyright (c) Renewed Vision, LLC. All rights reserved.
#ifndef KaleidoscopeHelper_h
#define KaleidoscopeHelper_h

#define kaleidoscopeTransform(p, progress, power, speed)                        \
    {                                                                           \
        float t = pow(progress, power) * speed;                                 \
        p -= 0.5;                                                               \
        for (int i = 0; i < 7; i++)                                             \
        {                                                                       \
            p = vec2(sin(t) * p.x + cos(t) * p.y, sin(t) * p.y - cos(t) * p.x); \
            t += angle;                                                         \
            p = abs(mod(p, 2.0) - 1.0);                                         \
        }                                                                       \
        abs(mod(p, 1.0));                                                       \
    }

#endif  // KaleidoscopeHelper_h
