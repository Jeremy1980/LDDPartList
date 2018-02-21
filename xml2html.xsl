<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output version="1.0" encoding="utf-8" omit-xml-declaration="yes" method="html"/>
  <xsl:template match="/">
    <html>
      <head>
        <title>
          Bill Of Material
        </title>
      </head>
      <body>
        <table cellspacing="0" cellpadding="0" border="0">
          <thead>
            <tr bgcolor="#5E5A80">
              <td width="*"><font color="#FFFFFF">&#160;Part name</font></td>
              <td width="70"><font color="#FFFFFF">Colour</font></td>
              <td width="70"><font color="#FFFFFF">Quantity [pieces]</font></td>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="//part">
	      <xsl:variable name="element_id" select="@itemNos"/>
              <tr>
                <td>
                  <xsl:value-of select="@name"/>
		  <xsl:text>&#160;&#160;</xsl:text>
	          <a href="{concat('https://www.rebrickable.com/parts/',$element_id)}" target="brickset">&#187;</a>
                </td>
                <td align="right">
                  <xsl:value-of select="@materialID"/>
                </td>
                <td align="right">
                  <xsl:value-of select="@count"/>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>