#version 440

uniform vec2 halfResolution;

layout(location = 0) in vec2 vPosition;
layout(location = 1) in vec2 vUV;
layout(location = 2) in vec4 vTextColor;

layout(location = 0) out vec2 fUV;
layout(location = 1) out vec4 fTextColor;

void main()
{
    float x = (vPosition.x - halfResolution.x) / halfResolution.x;
	float y = (halfResolution.y - vPosition.y) / halfResolution.y;

	gl_Position = vec4(x, y, 0.0, 1.0);
    fUV = vUV;
	fTextColor = vTextColor;
}