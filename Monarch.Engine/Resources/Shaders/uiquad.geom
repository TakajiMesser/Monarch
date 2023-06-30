#version 440

uniform vec2 halfResolution;

layout(points) in;
layout(triangle_strip, max_vertices = 4) out;

/*layout(location = 0) in vec3 gRight[];
layout(location = 1) in vec3 gUp[];
layout(location = 2) in vec2 gCornerRadius[];
layout(location = 3) in vec2 gBorderThickness[];
layout(location = 4) in vec4 gColor[];
layout(location = 5) in vec4 gBorderColor[];

out vec4 fColor;
out vec2 fCornerRadius;
out vec2 fBorderThickness;
out vec4 fBorderColor;
out vec2 fUV;*/

void main()
{
    vec3 position = gl_in[0].gl_Position.xyz;

    /*fColor = gColor[0];
    fCornerRadius = gCornerRadius[0];
    fBorderThickness = gBorderThickness[0];
    fBorderColor = gBorderColor[0];*/

    vec3 right = vec3(0.5, 0.0, 0.0);
    vec3 up = vec3(0.0, 0.5, 0.0);
    //vec3 right = gRight[0];
    //vec3 up = gUp[0];

    //Size: new Vector2f(200f, 100f)
    //windowOptions.Size = new Vector2D<int>(800, 600);
    //gRight = vec3(vSize.x / halfResolution.x, 0.0, 0.0);
	//gUp = vec3(0.0, vSize.y / halfResolution.y, 0.0);

    /*float rightX = 0.0;
    if (gRight[0].x > 0 && gRight[0].y == 0.0 && gRight[0].z == 0.0)
    {
        rightX = 0.5;
    }
    else
    {
        rightX = 0.2;
    }

    vec3 right = vec3(rightX, 0.0, 0.0);*/

    gl_Position = vec4(position, 1.0);
    //fUV = vec2(0.0, 1.0);
    EmitVertex();

    position -= up;
    gl_Position = vec4(position, 1.0);
    //fUV = vec2(0.0, 0.0);
    EmitVertex();

    position += right + up;
    gl_Position = vec4(position, 1.0);
    //fUV = vec2(1.0, 1.0);
    EmitVertex();

    position -= up;
    gl_Position = vec4(position, 1.0);
    //fUV = vec2(1.0, 0.0);
    EmitVertex();

    /*vec3 up = vec3(0.0, 0.5, 0.0);
    vec3 right = vec3(0.5, 0.0, 0.0);
    gl_Position = vec4(position, 1.0);
    EmitVertex();

    position -= up;
    gl_Position = vec4(position, 1.0);
    EmitVertex();

    position += right + up;
    gl_Position = vec4(position, 1.0);
    EmitVertex();

    position -= up;
    gl_Position = vec4(position, 1.0);
    EmitVertex();*/

    EndPrimitive();
}