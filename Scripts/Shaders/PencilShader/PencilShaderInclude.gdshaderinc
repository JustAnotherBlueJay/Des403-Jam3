//the pencil texture to blend with
uniform sampler2D u_patternTexture: repeat_enable;
instance uniform float rotation;
instance uniform float pencilTexScale = 1.0;
instance uniform float colorCorrection = 0.95;

vec2 rotateUV(vec2 uv, vec2 pivot)
{
	
	mat2 rotation_matrix = mat2( vec2(sin(rotation), -cos(rotation)),
								vec2(cos(rotation),sin(rotation))
								);
	uv -= pivot;
	uv = uv * rotation_matrix;
	uv += pivot;
	return uv;
	
}
vec4 pencil_fragment(sampler2D texture, vec2 uv, float frame, vec2 texture_pixel_size)
{
	//offset the pattern
	vec2 pattern_uv;
	pattern_uv = uv + sin(frame);
	//pattern_uv = rotateUV(pattern_uv, 0.5 / texture_pixel_size);
	pattern_uv = rotateUV(pattern_uv, vec2(0.5));
	
	
	vec4 base_color = texture(texture, uv);
	//UV * X scales the texture, texture(..) * X brightens the texture
	vec4 pattern_color = texture(u_patternTexture,pattern_uv * pencilTexScale) ;
	
	vec4 return_color = base_color / pattern_color;
	return_color.rgb = return_color.rgb * colorCorrection;
	return return_color;

}


