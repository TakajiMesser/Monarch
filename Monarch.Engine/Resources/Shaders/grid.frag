#version 440

layout(location = 0) in vec4 fColor;

layout(location = 0) out vec4 color;

void main()
{
    color = fColor;
}