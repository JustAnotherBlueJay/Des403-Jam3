shader_type canvas_item;

uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, repeat_disable, filter_nearest;
uniform sampler2D u_patternTexture;

void fragment()
{
	COLOR = texture(TEXTURE, UV) * texture(u_patternTexture, UV);
}