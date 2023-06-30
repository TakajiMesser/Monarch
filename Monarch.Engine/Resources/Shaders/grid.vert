#version 440

uniform mat4 modelMatrix;
uniform mat4 viewMatrix;
uniform mat4 projectionMatrix;

layout(location = 0) in vec3 vPosition;
layout(location = 1) in vec4 vInnerColor;
layout(location = 2) in vec4 vBorderColor;

out vec3 gPosition;
out vec4 gInnerColor;
out vec4 gBorderColor;
out vec4 gClipPosition;

void main()
{
    mat4 mvp = projectionMatrix * viewMatrix * modelMatrix;
    vec4 position = vec4(vPosition, 1.0);

    gPosition = (modelMatrix * position).xyz;
    gInnerColor = vInnerColor;
    gBorderColor = vBorderColor;
    gClipPosition = mvp * position;

    gl_Position = gClipPosition;
}