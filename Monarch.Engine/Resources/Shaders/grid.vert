#version 440

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

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

    mat4 mvp = /*projectionMatrix * viewMatrix **/ modelMatrix;
    vec4 position = vec4(vPosition, 1.0);

    gPosition = (modelMatrix * position).xyz;
    gBorderThickness = vBorderThickness;
    gInnerColor = vInnerColor;
    gBorderColor = vBorderColor;

    gl_Position = mvp * position;
}