<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output version="1.0" encoding="utf-8" omit-xml-declaration="yes" method="text" indent="yes"/>
  <xsl:template match="/">
    <xsl:text>part_num,quantity</xsl:text><!-- header line. -->
    <xsl:text>&#xd;&#xa;</xsl:text><!-- This is the newline on dos. -->
    <xsl:for-each select="//part">
      <xsl:value-of select="@designID"/>,<xsl:value-of select="@count"/>
      <xsl:text>&#xd;&#xa;</xsl:text><!-- This is the newline on dos. -->
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>