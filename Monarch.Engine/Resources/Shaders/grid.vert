#version 440

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;
uniform float radius;
uniform float apothem;

layout(location = 0) in vec3 vPosition;
layout(location = 1) in float vBorderThickness;
layout(location = 2) in vec4 vInnerColor;
layout(location = 3) in vec4 vBorderColor;

layout(location = 0) out vec3 gPosition;
layout(location = 1) out float gBorderThickness;
layout(location = 2) out vec4 gInnerColor;
layout(location = 3) out vec4 gBorderColor;

void main()
{
    //gPosition = vec3(0.0, 0.0, 0.0);
    //gl_Position = vec4(0.0, 0.0, 0.0, 1.0);
    //vec4 position = vec4(vPosition, 1.0);
    //float q = vPosition.x;
    //float r = vPosition.y;
    //float z = vPosition.z;
    //float u =  vPosition.x * radius  * 1.0 - vPosition.y * radius  * 0.5 - vPosition.z * radius  * 0.5;
    //float v = -vPosition.x * apothem * 0.0 - vPosition.y * apothem * 1.0 + vPosition.z * apothem * 1.0;
    
    // Convert from Grid-Space to Model-Space
    float u = (vPosition.x - vPosition.y * 0.5 - vPosition.z * 0.5) * radius;
    float v = (vPosition.z - vPosition.y) * apothem;

    mat4 mvp = /*projectionMatrix * viewMatrix **/ modelMatrix;
    vec4 position = vec4(u, v, 0.0, 1.0);

    gPosition = (modelMatrix * position).xyz;
    gBorderThickness = vBorderThickness;
    gInnerColor = vInnerColor;
    gBorderColor = vBorderColor;

    gl_Position = mvp * position;
}